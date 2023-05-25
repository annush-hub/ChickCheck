import React from "react";
import { Barn } from "../../../app/models/barn";
import { Label, Table } from "semantic-ui-react";
import { Feeder } from "../../../app/models/feeder";

interface Props {
  barn: Barn;
}

export default function BarnFeeders({ barn }: Props) {
  return (
    <div>
      <h3>Barn Feeders:</h3>
      <Table celled>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>Feeder ID</Table.HeaderCell>
            <Table.HeaderCell>Capacity</Table.HeaderCell>
            <Table.HeaderCell>Fullness</Table.HeaderCell>
            <Table.HeaderCell></Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {barn.feeders.map((feeder: Feeder) => (
            <Table.Row key={feeder.id}>
              <Table.Cell>{feeder.id}</Table.Cell>
              <Table.Cell>{feeder.capacity} літрів</Table.Cell>
              <Table.Cell>{feeder.fullness} %</Table.Cell>
              {/* <Table.Cell>{feeder.isInUse ? "Yes" : "No"}</Table.Cell> */}
              <Table.Cell>
                {feeder.fullness <= 0 && (
                  <Label as="a" color="red" ribbon="right">
                    Empty
                  </Label>
                )}
                {feeder.fullness > 0 && feeder.fullness <= 10 && (
                  <Label as="a" color="orange" ribbon="right">
                    Almost Empty
                  </Label>
                )}
              </Table.Cell>
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    </div>
  );
}
