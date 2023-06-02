import { createContext, useContext } from "react";
import BarnStore from "./barnStore";
import EggGradeStore from "./eggGradeStore";
import CommonStore from "./commonStore";
import StorageStore from "./storageStore";
import UserStore from "./userStore";
import ModalStore from "./modalStore";
import FeederStore from "./feederStore";

interface Store {
  barnStore: BarnStore;
  eggGradeStore: EggGradeStore;
  storageStore: StorageStore;
  commonStore: CommonStore;
  userStore: UserStore;
  modalStore: ModalStore;
  feederStore: FeederStore;
}

export const store: Store = {
  barnStore: new BarnStore(),
  eggGradeStore: new EggGradeStore(),
  storageStore: new StorageStore(),
  commonStore: new CommonStore(),
  userStore: new UserStore(),
  modalStore: new ModalStore(),
  feederStore: new FeederStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
