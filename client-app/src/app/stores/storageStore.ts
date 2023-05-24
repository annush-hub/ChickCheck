import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { v4 as uuid } from "uuid";
import { EggStorage } from "../models/storage";

export default class StorageStore {
  storageRegistry = new Map<string, EggStorage>();
  loading = false;
  loadingiInitial = false;

  constructor() {
    makeAutoObservable(this);
  }

  get storageList() {
    return Array.from(this.storageRegistry.values()).sort((a, b) =>
      a.name.localeCompare(b.name)
    );
  }

  private setStorage = (storage: EggStorage) => {
    this.storageRegistry.set(storage.id, storage);
  };

  loadStorages = async () => {
    this.setLoadingInitial(true);
    try {
      const storages = await agent.Storages.list();
      storages.forEach((storage) => {
        this.setStorage(storage);
      });
      this.setLoadingInitial(false);
    } catch (error) {
      console.log(error);
      this.setLoadingInitial(false);
    }
  };

  setLoadingInitial = (state: boolean) => {
    this.loadingiInitial = state;
  };
}
