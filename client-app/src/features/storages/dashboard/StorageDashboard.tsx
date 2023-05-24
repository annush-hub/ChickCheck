import React, { useEffect } from "react";
import { Grid, GridColumn } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import StorageList from "./StorageList";
import { useStore } from "../../../app/stores/store";

export default observer(function StorageDashboard() {
  const { storageStore } = useStore();
  const { storageList, loadStorages, storageRegistry } = storageStore;

  useEffect(() => {
    if (storageRegistry.size <= 1) loadStorages();
  }, [loadStorages, storageRegistry]);

  useEffect(() => {
    storageStore.loadStorages();
  }, [storageStore]);

  return (
    <Grid>
      <Grid.Column width="16">
        <StorageList />
      </Grid.Column>
    </Grid>
  );
});
