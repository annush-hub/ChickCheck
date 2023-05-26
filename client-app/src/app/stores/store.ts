import { createContext, useContext } from "react";
import BarnStore from "./barnStore";
import EggGradeStore from "./eggGradeStore";
import CommonStore from "./commonStore";
import StorageStore from "./storageStore";
import UserStore from "./userStore";

interface Store {
  barnStore: BarnStore;
  eggGradeStore: EggGradeStore;
  storageStore: StorageStore;
  commonStore: CommonStore;
  userStore: UserStore;
}

export const store: Store = {
  barnStore: new BarnStore(),
  eggGradeStore: new EggGradeStore(),
  storageStore: new StorageStore(),
  commonStore: new CommonStore(),
  userStore: new UserStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
