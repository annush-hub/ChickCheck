import React, { useEffect } from "react";
import { Grid, GridColumn } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import StorageList from "./StorageList";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useTranslation } from "react-i18next";

export default observer(function StorageDashboard() {
  const { storageStore } = useStore();
  const { loadStorages, storageRegistry } = storageStore;
  const { t } = useTranslation();

  useEffect(() => {
    if (storageRegistry.size <= 1) loadStorages();
  }, [loadStorages, storageRegistry]);

  useEffect(() => {
    storageStore.loadStorages();
  }, [storageStore]);

  if (storageStore.loadingiInitial)
    return <LoadingComponent content={t("loadingComponent.loadingStorages")} />;

  return (
    <Grid>
      <Grid.Column width="16">
        <StorageList />
      </Grid.Column>
    </Grid>
  );
});
