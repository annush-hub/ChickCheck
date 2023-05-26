import React from "react";
import { useTranslation } from "react-i18next";
import { Dimmer, Loader } from "semantic-ui-react";

interface Props {
  inverted?: boolean;
  content?: any;
}

export default function LoadingComponent({ inverted = true, content }: Props) {
  const { t } = useTranslation();
  return (
    <Dimmer active={true} inverted={inverted}>
      <Loader content={content || t("loadingComponent.loading")} />
    </Dimmer>
  );
}
