import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { EggStorage } from "../models/storage";

export default class StorageStore {
  storageRegistry = new Map<string, EggStorage>();
  loading = false;
  loadingiInitial = false;

  constructor() {
    makeAutoObservable(this);
  }

  get storageList() {
    return Array.from(this.storageRegistry.values());
  }

  private setStorage = (storage: EggStorage) => {
    this.storageRegistry.set(storage.id, storage);
  };

  loadStorages = async () => {
    this.setLoadingInitial(true);
    try {
      const storages = await agent.Storages.list();
      console.log(storages);
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
