import { ErrorMessage, Form, Formik } from "formik";
import React from "react";
import MyTextInput from "../../app/common/form/MyTextInput";
import { Button, Header, Label } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import { useTranslation } from "react-i18next";

export default observer(function LoginForm() {
  const { userStore } = useStore();
  const { t } = useTranslation();
  return (
    <Formik
      initialValues={{ email: "", password: "", error: null }}
      onSubmit={(values, { setErrors }) =>
        userStore
          .login(values)
          .catch((error) =>
            setErrors({ error: t("userFormErrors.invalidLogin")! })
          )
      }
    >
      {({ handleSubmit, isSubmitting, errors }) => (
        <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
          <Header
            as="h2"
            content={t("homePage.login")}
            color="teal"
            textAlign="center"
          />
          <MyTextInput placeholder={t("user.email")} name="email" />
          <MyTextInput
            placeholder={t("user.password")}
            name="password"
            type="password"
          />
          <ErrorMessage
            name="error"
            render={(error) => (
              <Label
                style={{ marginBottom: 10 }}
                basic
                color="red"
                content={errors.error}
              />
            )}
          />
          <Button
            loading={isSubmitting}
            positive
            content={t("homePage.login")}
            type="submit"
            fluid
          />
        </Form>
      )}
    </Formik>
  );
});
