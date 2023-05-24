import { makeAutoObservable } from "mobx";
import { Barn } from "../models/barn";
import agent from "../api/agent";
import { EggGrade } from "../models/eggGrade";

export default class EggGradeStore {
  eggGradeRegistry = new Map<string, EggGrade>();
  selectedEggGrade: Barn | undefined = undefined;
  loadingiInitial = true;

  constructor() {
    makeAutoObservable(this);
  }

  get eggGradeList() {
    return Array.from(this.eggGradeRegistry.values());
  }

  loadEggGrades = async () => {
    try {
      const eggGrades = await agent.EggGrades.list();
      eggGrades.forEach((eggGrade) => {
        this.eggGradeRegistry.set(eggGrade.id, eggGrade);
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
