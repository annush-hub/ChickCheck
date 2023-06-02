import React, { useEffect, useState } from "react";
import { Grid, GridColumn, Loader } from "semantic-ui-react";
import BarnList from "./BarnList";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import BarnFilters from "./BarnFilters";
import { useTranslation } from "react-i18next";
import { PagingParams } from "../../../app/models/pagination";
import InfiniteScroll from "react-infinite-scroller";

export default observer(function BarnDashboard() {
  const { barnStore, eggGradeStore } = useStore();
  const { loadBarns, barnRegistry, setPagingParams, pagination } = barnStore;
  const { t } = useTranslation();
  const [loadingNext, setLoadingNext] = useState(false);

  function handleGetNext() {
    setLoadingNext(true);
    setPagingParams(new PagingParams(pagination!.currentPage + 1));
    loadBarns().then(() => setLoadingNext(false));
  }

  useEffect(() => {
    if (barnRegistry.size <= 1) loadBarns();
  }, [loadBarns, barnRegistry]);

  useEffect(() => {
    eggGradeStore.loadEggGrades();
  }, [eggGradeStore]);

  if (barnStore.loadingiInitial && !loadingNext)
    return <LoadingComponent content={t("loadingComponent.loadingBarns")} />;

  return (
    <Grid>
      <Grid.Column width="10">
        <InfiniteScroll
          pageStart={0}
          loadMore={handleGetNext}
          hasMore={
            !loadingNext &&
            !!pagination &&
            pagination.currentPage < pagination.totalPages
          }
          initialLoad={false}
        >
          <BarnList />
        </InfiniteScroll>
      </Grid.Column>
      <GridColumn width="6">
        <BarnFilters />
      </GridColumn>
      <Grid.Column width={10}>
        <Loader active={loadingNext} />
      </Grid.Column>
    </Grid>
  );
});
