import { observer } from "mobx-react-lite";
import React from "react";
import { Segment, Grid, Icon } from "semantic-ui-react";
import { Barn } from "../../../app/models/barn";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faEgg,
  faTemperatureThreeQuarters,
} from "@fortawesome/free-solid-svg-icons";
import { EggGrade } from "../../../app/models/eggGrade";
import { useTranslation } from "react-i18next";
import i18n from "../../../i18n";

interface Props {
  barn: Barn;
  eggGrades: EggGrade[];
}

export default observer(function BarnDetailedInfo({ barn, eggGrades }: Props) {
  const { t } = useTranslation();

  const displayTemperature =
    i18n.language === "en"
      ? barn!.temperatureInFahrenheit
      : barn!.temperatureInCelsius;

  const temperatureUnit = i18n.language === "en" ? "°F" : "°C";
  return (
    <Segment.Group>
      <Segment attached="top">
        <Grid>
          <Grid.Column width={1}>
            <Icon size="large" style={{ color: "#68C6B8" }} name="info" />
          </Grid.Column>
          <Grid.Column width={15}>
            <p>{barn.description}</p>
          </Grid.Column>
        </Grid>
      </Segment>
      <Segment attached>
        <Grid verticalAlign="middle">
          <Grid.Column width={1}>
            <FontAwesomeIcon
              icon={faEgg}
              color="teal"
              style={{ fontSize: "1.7em", color: "#68C6B8" }}
            />
          </Grid.Column>
          <Grid.Column width={11}>
            <span>
              {i18n.language === "en"
                ? eggGrades.find((x) => x.id === barn.eggGradeId)?.gradeEU
                : eggGrades.find((x) => x.id === barn.eggGradeId)?.gradeUA}
            </span>
          </Grid.Column>
        </Grid>
      </Segment>
      <Segment attached>
        <Grid verticalAlign="middle">
          <Grid.Column width={1}>
            <FontAwesomeIcon
              icon={faTemperatureThreeQuarters}
              color="teal"
              style={{ fontSize: "1.7em", color: "#68C6B8" }}
            />
          </Grid.Column>
          <Grid.Column width={11}>
            <span>
              {displayTemperature} {temperatureUnit}
            </span>
          </Grid.Column>
        </Grid>
      </Segment>
    </Segment.Group>
  );
});
