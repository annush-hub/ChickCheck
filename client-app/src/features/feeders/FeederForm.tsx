import React, { useState } from "react";
import { useStore } from "../../app/stores/store";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { Button, Form, Segment } from "semantic-ui-react";

interface Props {
  onCancel: () => void;
}

export default function FeederForm({ onCancel }: Props) {
  const { barnStore } = useStore();
  const {
    selectedBarn,
    createBarn,
    updateBarn,
    loading,
    loadBarn,
    loadingiInitial,
  } = barnStore;

  const { id } = useParams();
  const { t } = useTranslation();
  const navigate = useNavigate();
  return (
    <Segment clearing>
      <Form autoComplete="off">
        <Form.Input
          label={t("barnFeeders.capacity")}
          type="number"
          placeholder={t("barnFeeders.capacity")}
          name="capacity"
        />
        <Form.Input
          label={t("barnFeeders.fullness")}
          type="number"
          placeholder={t("barnFeeders.fullness")}
          name="fullness"
        />

        <Button
          floated="right"
          positive
          type="submit"
          content={t("barnForm.submit")}
          loading={loading}
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
