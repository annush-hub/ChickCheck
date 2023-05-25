import { EggGrade } from "./eggGrade";

export interface EggStorage {
  id: string;
  name: string;
  city: string;
  region: string;
  isWorking: boolean;
  eggGrades: EggGrade[];
}
