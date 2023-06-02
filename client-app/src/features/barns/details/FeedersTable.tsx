import React, { useEffect } from "react";
import { Barn } from "../../../app/models/barn";
import { Label, Table } from "semantic-ui-react";
import { Feeder } from "../../../app/models/feeder";
import { useTranslation } from "react-i18next";

interface Props {
  barn: Barn;
}

export default function FeedersTable({ barn }: Props) {
  const { t } = useTranslation();

  return (
    <div>
      <Table celled>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>{t("barnFeeders.feederId")}</Table.HeaderCell>
            <Table.HeaderCell>{t("barnFeeders.capacity")}</Table.HeaderCell>
            <Table.HeaderCell>{t("barnFeeders.fullness")}</Table.HeaderCell>
            <Table.HeaderCell></Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {barn.feeders.map((feeder: Feeder) => (
            <Table.Row key={feeder.id}>
              <Table.Cell>{feeder.id}</Table.Cell>
              <Table.Cell>
                {feeder.capacity} {t("unionsOfMeasurement.capacity")}
              </Table.Cell>
              <Table.Cell>{feeder.fullness} %</Table.Cell>
              <Table.Cell>
                {feeder.fullness <= 0 && (
                  <Label as="a" color="red" ribbon="right">
                    {t("barnFeeders.empty")}
                  </Label>
                )}
                {feeder.fullness > 0 && feeder.fullness <= 10 && (
                  <Label as="a" color="orange" ribbon="right">
                    {t("barnFeeders.alEmpty")}
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
function fetchData() {
  throw new Error("Function not implemented.");
}
