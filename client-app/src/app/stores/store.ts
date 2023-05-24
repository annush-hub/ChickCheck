import { createContext, useContext } from "react";
import BarnStore from "./barnStore";
import EggGradeStore from "./eggGradeStore";
import CommonStore from "./commonStore";
import StorageStore from "./storageStore";

interface Store {
  barnStore: BarnStore;
  eggGradeStore: EggGradeStore;
  storageStore: StorageStore;
  commonStore: CommonStore;
}

export const store: Store = {
  barnStore: new BarnStore(),
  eggGradeStore: new EggGradeStore(),
  storageStore: new StorageStore(),
  commonStore: new CommonStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
