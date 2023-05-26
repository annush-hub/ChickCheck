import React, { useEffect, useState } from "react";
import { Button, FormField, Header, Label, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Barn } from "../../../app/models/barn";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useTranslation } from "react-i18next";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import MyTextInput from "../../../app/common/form/MyTextInput";
import { v4 as uuid } from "uuid";

export default observer(function BarnForm() {
  const { barnStore, eggGradeStore } = useStore();
  const { createBarn, updateBarn, loading, loadBarn, loadingiInitial } =
    barnStore;

  const { id } = useParams();
  const { t, i18n } = useTranslation();

  const temperatureLabel =
    i18n.language === "ua"
      ? t("unionsOfMeasurement.temperatureInCelsius")
      : t("unionsOfMeasurement.temperatureInFahrenheit");
  const temperatureFieldName =
    i18n.language === "ua" ? "temperatureInCelsius" : "temperatureInFahrenheit";
  const navigate = useNavigate();

  const [barn, setBarn] = useState<Barn>({
    id: "",
    name: "",
    description: "",
    temperatureInCelsius: 0,
    temperatureInFahrenheit: 0,
    isDeactivated: false,
    eggGradeId: "",
    feeders: [],
  });

  const validationSchema = Yup.object({
    name: Yup.string().required(t("barnFormErrors.name")!),
    description: Yup.string().required(t("barnFormErrors.description")!),
    temperatureInCelsius: Yup.number().min(1, t("barnFormErrors.temperature")!),
    eggGradeId: Yup.string().required(t("barnFormErrors.eggGrade")!),
  });

  useEffect(() => {
    if (id) {
      loadBarn(id).then((barn) => {
        if (barn) {
          setBarn(barn);
          setSelectedEggGrade(barn.eggGradeId);
        }
      });
    }
  }, [id, loadBarn]);

  const { eggGradeList: eggGrades } = eggGradeStore;

  const [selectedEggGrade, setSelectedEggGrade] = useState<string>(
    barn.eggGradeId
  );
  if (loadingiInitial)
    return <LoadingComponent content={t("loadingComponent.loadingBarn")} />;

  function handleFormSubmit(barn: Barn) {
    if (!barn.id) {
      barn.id = uuid();
      createBarn(barn).then(() => navigate(`/barns/${barn.id}`));
    } else {
      updateBarn(barn).then(() => navigate(`/barns/${barn.id}`));
    }
  }

  return (
    <Segment clearing>
      <Formik
        validationSchema={validationSchema}
        enableReinitialize
        initialValues={barn}
        onSubmit={(values) => handleFormSubmit(values)}
      >
        {({
          values: barn,
          handleChange,
          handleSubmit,
          isValid,
          dirty,
          isSubmitting,
        }) => (
          <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
            <MyTextInput name="name" placeholder={t("barnForm.name")} />

            <MyTextInput
              placeholder={t("barnForm.description")}
              name="description"
            />
            <FormField>
              <label htmlFor="temperature">
                {i18n.language === "ua"
                  ? t("unionsOfMeasurement.temperatureInCelsius")
                  : t("unionsOfMeasurement.temperatureInFahrenheit")}
              </label>
              <Field
                llabel={temperatureLabel}
                type="number"
                placeholder={temperatureLabel}
                name={temperatureFieldName}
              />
              <ErrorMessage
                name={temperatureFieldName}
                render={(error) => <Label basic color="red" content={error} />}
              />
            </FormField>

            <FormField>
              <label htmlFor="eggGradeId">{t("barnForm.eggGrade")}</label>
              <Field
                as="select"
                id="eggGradeId"
                name="eggGradeId"
                onChange={handleChange}
              >
                <option value="">{t("barnForm.selectEggGrade")}</option>
                {eggGrades.map((eggGrade) => (
                  <option
                    key={eggGrade.id}
                    value={eggGrade.id} // Set the 'selected' attribute based on the comparison
                  >
                    {eggGrade.gradeUA}
                  </option>
                ))}
              </Field>
              <ErrorMessage
                name="eggGradeId"
                render={(error) => <Label basic color="red" content={error} />}
              />
            </FormField>

            <label style={{ margin: 5 }}>{t("barnForm.isDeactivated")}</label>
            <Field
              type="checkbox"
              name="isDeactivated"
              checked={barn.isDeactivated}
              onChange={handleChange}
            />

            <Button
              disabled={isSubmitting || !isValid || !dirty}
              floated="right"
              positive
              type="submit"
              content={t("barnForm.submit")}
              loading={loading}
            />
            <Button
              as={Link}
              to="/barns"
              floated="right"
              type="button"
              content={t("barnForm.cancel")}
            />
          </Form>
        )}
      </Formik>
    </Segment>
  );
});
