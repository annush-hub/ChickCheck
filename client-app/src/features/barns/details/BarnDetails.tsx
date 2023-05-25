import React, { useEffect } from "react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { observer } from "mobx-react-lite";
import { useParams } from "react-router-dom";
import BarnDetailedInfo from "./BarnDetailedInfo";
import BarnDetailedHeader from "./BarnDetailedHeader";
import BarnFeeders from "./BarnFeeders";

export default observer(function BarnDetails() {
  const { barnStore, eggGradeStore } = useStore();
  const { selectedBarn: barn, loadBarn, loadingiInitial } = barnStore;
  const { id } = useParams();
  const { eggGradeList: eggGrades } = eggGradeStore;

  useEffect(() => {
    if (id) loadBarn(id);
  }, [id, loadBarn]);

  if (loadingiInitial || !barn) return <LoadingComponent />;

  return (
    <>
      <BarnDetailedHeader barn={barn} />
      <BarnDetailedInfo barn={barn} eggGrades={eggGrades} />
      <BarnFeeders barn={barn} />
    </>
  );
});
