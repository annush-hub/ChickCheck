import React, { useEffect, useState } from "react";
import { Grid, GridColumn, Header } from "semantic-ui-react";
import BarnList from "./BarnList";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import BarnFilters from "./BarnFilters";
import { useTranslation } from "react-i18next";

export default observer(function BarnDashboard() {
  const { barnStore, eggGradeStore } = useStore();
  const { loadBarns, barnRegistry } = barnStore;
  const { t } = useTranslation();

  useEffect(() => {
    if (barnRegistry.size <= 1) loadBarns();
  }, [loadBarns, barnRegistry]);

  useEffect(() => {
    eggGradeStore.loadEggGrades();
  }, [eggGradeStore]);

  if (barnStore.loadingiInitial || eggGradeStore.loadingiInitial)
    return <LoadingComponent content={t("loadingComponent.loadingBarns")} />;

  return (
    <Grid>
      <Grid.Column width="10">
        <BarnList />
      </Grid.Column>
      <GridColumn width="6">
        <BarnFilters />
      </GridColumn>
    </Grid>
  );
});
