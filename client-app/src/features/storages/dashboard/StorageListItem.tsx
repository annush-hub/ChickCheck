import React from "react";
import { Item, Segment } from "semantic-ui-react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faLocationDot } from "@fortawesome/free-solid-svg-icons";
import { EggStorage } from "../../../app/models/storage";

interface Props {
  storage: EggStorage;
}

export default function StorageListItem({ storage }: Props) {
  return (
    <Segment.Group>
      <Segment>
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
          <FontAwesomeIcon icon={faLocationDot} />
          {storage.city}, {storage.region}
        </span>
      </Segment>
    </Segment.Group>
  );
}
