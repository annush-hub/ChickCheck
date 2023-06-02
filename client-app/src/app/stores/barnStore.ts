import { makeAutoObservable, reaction, runInAction } from "mobx";
import { Barn } from "../models/barn";
import agent from "../api/agent";
import { v4 as uuid } from "uuid";
import { Pagination, PagingParams } from "../models/pagination";

export default class BarnStore {
  barnRegistry = new Map<string, Barn>();
  selectedBarn: Barn | undefined = undefined;
  editMode = false;
  loading = false;
  loadingiInitial = false;
  pagination: Pagination | null = null;
  pagingParams = new PagingParams();
  predicate = new Map().set("all", true);

  constructor() {
    makeAutoObservable(this);
    reaction(
      () => this.predicate.keys(),
      () => {
        this.pagingParams = new PagingParams();
        this.barnRegistry.clear();
        this.loadBarns();
      }
    );
  }

  get barnsList() {
    // return Array.from(this.barnRegistry.values()).sort((a, b) =>
    //   a.name.localeCompare(b.name)
    // );
    return Array.from(this.barnRegistry.values());
  }

  setPagingParams = (pagingParams: PagingParams) => {
    this.pagingParams = pagingParams;
  };

  setPredicate = (predicate: string, value: boolean) => {
    const resetPredicate = () => {
      this.predicate.forEach((value, key) => {
        this.predicate.delete(key);
      });
    };
    switch (predicate) {
      case "all":
        resetPredicate();
        this.predicate.set("all", true);
        break;
      case "isActive":
        resetPredicate();
        this.predicate.set("isActive", true);
        break;
      case "isInactive":
        resetPredicate();
        this.predicate.set("isInactive", true);
        break;
    }
  };

  get axiosParams() {
    const params = new URLSearchParams();
    params.append("pageNumber", this.pagingParams.pageNumber.toString());
    params.append("pageSize", this.pagingParams.pageSize.toString());
    this.predicate.forEach((value, key) => {
      params.append(key, value);
    });
    return params;
  }

  get groupedBarns() {
    return Object.entries(
      this.barnsList.reduce((barns, barn) => {
        const grade = barn.eggGradeId;
        barns[grade] = barns[grade] ? [...barns[grade], barn] : [barn];
        return barns;
      }, {} as { [key: string]: Barn[] })
    );
  }

  private setBarn = (barn: Barn) => {
    this.barnRegistry.set(barn.id, barn);
  };

  loadBarns = async () => {
    this.setLoadingInitial(true);
    try {
      const result = await agent.Barns.list(this.axiosParams);
      result.data.forEach((barn) => {
        this.setBarn(barn);
      });
      this.setPagination(result.pagination);
      this.setLoadingInitial(false);
    } catch (error) {
      console.log(error);
      this.setLoadingInitial(false);
    }
  };

  setPagination = (pagination: Pagination) => {
    this.pagination = pagination;
  };

  loadBarn = async (id: string) => {
    let barn = this.getBarn(id);
    if (barn) {
      this.selectedBarn = barn;
      return barn;
    } else {
      this.setLoadingInitial(true);
      try {
        barn = await agent.Barns.details(id);
        this.setBarn(barn);
        // this.selectedBarn = barn;
        runInAction(() => (this.selectedBarn = barn));
        this.setLoadingInitial(false);
        return barn;
      } catch (error) {
        console.log(error);
        this.setLoadingInitial(false);
      }
    }
  };

  private getBarn = (id: string) => {
    return this.barnRegistry.get(id);
  };

  setLoadingInitial = (state: boolean) => {
    this.loadingiInitial = state;
  };

  createBarn = async (barn: Barn) => {
    this.loading = true;
    barn.id = uuid();
    try {
      await agent.Barns.create(barn);
      runInAction(() => {
        this.barnRegistry.set(barn.id, barn);
        this.selectedBarn = barn;
        this.editMode = false;
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loading = false;
      });
    }
  };

  updateBarn = async (barn: Barn) => {
    this.loading = true;
    try {
      await agent.Barns.update(barn);
      runInAction(() => {
        this.barnRegistry.set(barn.id, barn);
        this.selectedBarn = barn;
        this.editMode = false;
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loading = false;
      });
    }
  };
}
