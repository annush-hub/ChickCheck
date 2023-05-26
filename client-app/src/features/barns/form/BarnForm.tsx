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
  const { t } = useTranslation();
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
    name: Yup.string().required("The barn name is required"),
    description: Yup.string().required("The barn description is required"),
    temperatureInCelsius: Yup.number()
      .typeError("Temperature must be a number")
      .positive("Temperature must be a positive number")
      .min(1, "Temperature must be greater than zero")
      .required("Temperature is required"),
    eggGradeId: Yup.string().required("The barn egg Grade is required"),
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
  if (loadingiInitial) return <LoadingComponent content="Loading barn..." />;

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
      <Header content="Barn Details" sub color="teal" />
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
            <MyTextInput name="name" placeholder="Name" />

            <MyTextInput
              placeholder={t("barnForm.description")}
              name="description"
            />
            <FormField>
              <label htmlFor="eggGradeId">{t("barnForm.eggGrade")}</label>
              <Field
                label={t("barnForm.temperature")}
                type="number"
                placeholder="Temperature in Celcius"
                name="temperatureInCelsius"
              />
              <ErrorMessage
                name="temperatureInCelsius"
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

            <label>{t("barnForm.isDeactivated")}</label>
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
