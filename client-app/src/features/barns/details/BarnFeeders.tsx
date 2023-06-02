import React, { useState } from "react";
import FeedersTable from "./FeedersTable";
import { Barn } from "../../../app/models/barn";
import { Button, Grid, GridColumn } from "semantic-ui-react";
import { useTranslation } from "react-i18next";
import FeederForm from "../../feeders/FeederForm";
import { v4 as uuid } from "uuid";

interface Props {
  barn: Barn;
}

export default function BarnFeeders({ barn }: Props) {
  const { t } = useTranslation();
  const [isShown, setIsShown] = useState(false);
  const [reloadKey, setReloadKey] = useState("");

  const toggleFormVisibility = () => {
    setIsShown((current) => !current);
  };

  return (
    <>
      <h3>{t("barnFeeders.title")}</h3>

      <Grid>
        <Grid.Row>
          <Button
            onClick={toggleFormVisibility}
            floated="right"
            positive
            style={{ margin: 5 }}
          >
            {t("barnFeeders.addFeeder")}
          </Button>
        </Grid.Row>

        <Grid.Column width={10}>
          {" "}
          <FeedersTable barn={barn} />
        </Grid.Column>
        <Grid.Column width={6}>
          {" "}
          {isShown && <FeederForm onCancel={toggleFormVisibility} />}
        </Grid.Column>
      </Grid>
    </>
  );
}
