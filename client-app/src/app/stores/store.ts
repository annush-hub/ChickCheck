import { createContext, useContext } from "react";
import BarnStore from "./barnStore";
import EggGradeStore from "./eggGradeStore";
import CommonStore from "./commonStore";

interface Store {
  barnStore: BarnStore;
  eggGradeStore: EggGradeStore;
  commonStore: CommonStore;
}

export const store: Store = {
  barnStore: new BarnStore(),
  eggGradeStore: new EggGradeStore(),
  commonStore: new CommonStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
