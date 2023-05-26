import { ErrorMessage, Form, Formik } from "formik";
import MyTextInput from "../../app/common/form/MyTextInput";
import { Button, Header, Label } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import * as Yup from "yup";
import ValidationError from "../errors/ValidationError";
import { useTranslation } from "react-i18next";

export default observer(function RegisterForm() {
  const { userStore } = useStore();
  const { t } = useTranslation();
  return (
    <Formik
      initialValues={{
        displayName: "",
        username: "",
        email: "",
        password: "",
        error: null,
      }}
      onSubmit={(values, { setErrors }) =>
        userStore.register(values).catch((error) => setErrors({ error }))
      }
      validationSchema={Yup.object({
        displayName: Yup.string().required(t("userFormErrors.displayName")!),
        username: Yup.string().required(t("userFormErrors.username")!),
        email: Yup.string()
          .required(t("userFormErrors.email")!)
          .email(t("userFormErrors.invalidEmail")!),
        bio: Yup.string().required(t("userFormErrors.bio")!),
        password: Yup.string()
          .required(t("userFormErrors.password")!)
          .matches(
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()])[A-Za-z\d!@#$%^&*()]{8,}$/,
            t("userFormErrors.weakPassword")!
          ),
      })}
    >
      {({ handleSubmit, isSubmitting, errors, isValid, dirty }) => (
        <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
          <Header
            as="h2"
            content={t("homePage.register")}
            color="teal"
            textAlign="center"
          />
          <MyTextInput placeholder={t("user.email")} name="email" />
          <MyTextInput placeholder={t("user.username")} name="username" />
          <MyTextInput placeholder={t("user.displayName")} name="displayName" />
          <MyTextInput placeholder={t("user.bio")} name="bio" />
          <MyTextInput
            placeholder={t("user.password")}
            name="password"
            type="password"
          />
          <ErrorMessage
            name="error"
            render={(error) => (
              <>
                <Label
                  style={{ marginBottom: 10 }}
                  basic
                  color="red"
                  content={errors.error}
                />
                <ValidationError erros={errors.error} />
              </>
            )}
          />
          <Button
            disabled={!isValid || !dirty || isSubmitting}
            loading={isSubmitting}
            positive
            content={t("homePage.register")}
            type="submit"
            fluid
          />
        </Form>
      )}
    </Formik>
  );
});
