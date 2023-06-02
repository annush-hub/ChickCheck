import { makeAutoObservable, runInAction } from "mobx";
import { Barn } from "../models/barn";
import agent from "../api/agent";
import { v4 as uuid } from "uuid";
import { Feeder } from "../models/feeder";

export default class FeederStore {
  feederRegistry = new Map<string, Feeder>();
  selectedBarn: Barn | undefined = undefined;
  editMode = false;
  loading = false;
  loadingiInitial = false;

  constructor() {
    makeAutoObservable(this);
  }

  createFeeder = async (feeder: Feeder, barnId: string) => {
    this.loading = true;
    feeder.id = uuid();
    feeder.barnId = barnId;
    feeder.capacity = feeder.capacity;
    feeder.fullness = feeder.fullness;

    try {
      await agent.Feeders.create(feeder);
      runInAction(() => {
        this.feederRegistry.set(feeder.id, feeder);
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
