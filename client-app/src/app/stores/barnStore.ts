import { makeAutoObservable, runInAction } from "mobx";
import { Barn } from "../models/barn";
import agent from "../api/agent";
import { v4 as uuid } from "uuid";

export default class BarnStore {
  barnRegistry = new Map<string, Barn>();
  selectedBarn: Barn | undefined = undefined;
  editMode = false;
  loading = false;
  loadingiInitial = false;

  constructor() {
    makeAutoObservable(this);
  }

  get barnsList() {
    return Array.from(this.barnRegistry.values()).sort((a, b) =>
      a.name.localeCompare(b.name)
    );
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
      const barns = await agent.Barns.list();
      barns.forEach((barn) => {
        this.setBarn(barn);
      });
      this.setLoadingInitial(false);
    } catch (error) {
      console.log(error);
      this.setLoadingInitial(false);
    }
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
        this.selectedBarn = barn;
        runInAction(() => (this.selectedBarn = barn));
        this.setLoadingInitial(false);
        return barn;
      } catch (error) {
        console.log(error);
        this.setLoadingInitial(false);
      }
    }
  };

  loadBarnWithFeeders = async (id: string) => {
    let barn = this.getBarn(id);
    if (barn) {
      this.selectedBarn = barn;
      return barn;
    } else {
      this.setLoadingInitial(true);
      try {
        barn = await agent.Barns.details(id);
        this.setBarn(barn);
        this.selectedBarn = barn;
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
