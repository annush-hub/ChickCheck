import React from "react";
import { Item, Label, Segment } from "semantic-ui-react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEgg, faLocationDot } from "@fortawesome/free-solid-svg-icons";
import { EggStorage } from "../../../app/models/storage";
import { useTranslation } from "react-i18next";
import i18n from "../../../i18n";

interface Props {
  storage: EggStorage;
}

export default function StorageListItem({ storage }: Props) {
  const getStatusColor = () => {
    return storage.isWorking ? "green" : "red";
  };
  const { t } = useTranslation();

  return (
    <Segment.Group>
      <Segment>
        <Label color={getStatusColor()}>
          {storage.isWorking
            ? t("storageList.working")
            : t("storageList.notWorking")}
        </Label>

        <Item.Group>
          <Item>
            <Item.Content>
              <Item.Header>{storage.name}</Item.Header>
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
      <Segment secondary>
        <span>
          <FontAwesomeIcon
            icon={faLocationDot}
            style={{ fontSize: "1.3em", color: "#68C6B8" }}
          />{" "}
          {storage.city}, {storage.region}
        </span>
      </Segment>
      <Segment>
        {i18n.language === "en"
          ? storage.eggGrades.map((eggGrade) => (
              <Label key={eggGrade.id}>
                {" "}
                <FontAwesomeIcon icon={faEgg} /> {eggGrade.gradeEU}
              </Label>
            ))
          : storage.eggGrades.map((eggGrade) => (
              <Label key={eggGrade.id}>
                {" "}
                <FontAwesomeIcon icon={faEgg} /> {eggGrade.gradeUA}
              </Label>
            ))}

        <span> </span>
      </Segment>
    </Segment.Group>
  );
}
