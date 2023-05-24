import { createContext, useContext } from "react";
import BarnStore from "./barnStore";
import EggGradeStore from "./eggGradeStore";

interface Store {
  barnStore: BarnStore;
  eggGradeStore: EggGradeStore;
}

export const store: Store = {
  barnStore: new BarnStore(),
  eggGradeStore: new EggGradeStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
