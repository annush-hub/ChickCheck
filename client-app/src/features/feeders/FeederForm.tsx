import React, { FormEvent, FormEventHandler, useState } from "react";
import { useStore } from "../../app/stores/store";
import { useNavigate, useParams } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { Button, Form, Segment } from "semantic-ui-react";
import { Feeder } from "../../app/models/feeder";
import { v4 as uuid } from "uuid";

interface Props {
  onCancel: () => void;
}

export default function FeederForm({ onCancel }: Props) {
  const { feederStore, eggGradeStore } = useStore();
  const { createFeeder } = feederStore;

  const { id } = useParams();
  const { t } = useTranslation();
  const navigate = useNavigate();
  const [formSubmitted, setFormSubmitted] = useState(false);

  const [feeder, setFeeder] = useState<Feeder>({
    id: "",
    capacity: 0,
    fullness: 0,
    isInUse: true,
    barnId: "",
  });

  const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const newFeeder: Feeder = {
      ...feeder,
      id: uuid(),
    };

    createFeeder(newFeeder, id!);
    setFormSubmitted(true);
    navigate("/barns");
  };

  if (formSubmitted) {
    return null;
  }

  return (
    <Segment clearing>
      <Form
        autoComplete="off"
        onSubmit={handleSubmit as FormEventHandler<HTMLFormElement>}
      >
        <Form.Input
          label={t("barnFeeders.capacity")}
          type="number"
          placeholder={t("barnFeeders.capacity")}
          name="capacity"
          onChange={(e) =>
            setFeeder({ ...feeder, capacity: parseInt(e.target.value) })
          }
        />
        <Button
          floated="right"
          positive
          type="submit"
          content={t("barnForm.submit")}
        />
        <Button
          onClick={onCancel}
          floated="right"
          type="button"
          content={t("barnForm.cancel")}
        />
      </Form>
    </Segment>
  );
}
