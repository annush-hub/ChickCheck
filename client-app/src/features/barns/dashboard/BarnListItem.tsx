import React from "react";
import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Barn } from "../../../app/models/barn";
import { Link } from "react-router-dom";
import { useStore } from "../../../app/stores/store";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faEgg,
  faTemperatureThreeQuarters,
} from "@fortawesome/free-solid-svg-icons";
import { useTranslation } from "react-i18next";
import i18n from "../../../i18n";

interface Props {
  barn: Barn;
}

export default function BarnListItem({ barn }: Props) {
  const { eggGradeStore } = useStore();
  const { eggGradeList: eggGrades } = eggGradeStore;
  const { t } = useTranslation();

  const displayTemperature =
    i18n.language === "en"
      ? barn.temperatureInFahrenheit
      : barn.temperatureInCelsius;

  const temperatureUnit = i18n.language === "en" ? "°F" : "°C";

  const getStatusColor = () => {
    return barn.isDeactivated ? "red" : "green";
  };

  return (
    <Segment.Group>
      <Segment>
        <Label color={getStatusColor()}>
          {!barn.isDeactivated
            ? t("storageList.working")
            : t("storageList.notWorking")}
        </Label>
        <Item.Group>
          <Item>
            <Item.Content>
              <Item.Header as={Link} to={`/barns/${barn.id}`}>
                {barn.name}
              </Item.Header>
              <Item.Description>
                <div>{barn.description}</div>{" "}
              </Item.Description>
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
      <Segment secondary>
        <span>
          <FontAwesomeIcon icon={faEgg} />
          {i18n.language === "en"
            ? eggGrades.find((x) => x.id === barn.eggGradeId)?.gradeEU
            : eggGrades.find((x) => x.id === barn.eggGradeId)?.gradeUA}
          <span> </span>
          <FontAwesomeIcon icon={faTemperatureThreeQuarters} />{" "}
          {displayTemperature} {temperatureUnit}
        </span>
      </Segment>
      <Segment clearing>
        <Button
          as={Link}
          to={`/barns/${barn.id}`}
          floated="right"
          content={t("barnList.itemView")}
          color="orange"
        />
      </Segment>
    </Segment.Group>
  );
}
