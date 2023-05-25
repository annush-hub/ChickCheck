import React from "react";
import { Item, Label, Segment } from "semantic-ui-react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEgg, faLocationDot } from "@fortawesome/free-solid-svg-icons";
import { EggStorage } from "../../../app/models/storage";

interface Props {
  storage: EggStorage;
}

export default function StorageListItem({ storage }: Props) {
  const getStatusColor = () => {
    return storage.isWorking ? "green" : "red";
  };

  return (
    <Segment.Group>
      <Segment>
        <Label color={getStatusColor()}>
          {storage.isWorking ? "Active" : "Inactive"}
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
        {storage.eggGrades.map((eggGrade) => (
          <Label key={eggGrade.id}>
            {" "}
            <FontAwesomeIcon icon={faEgg} /> {eggGrade.gradeUA}
          </Label>
        ))}
      </Segment>
    </Segment.Group>
  );
}
