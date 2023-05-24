import React from "react";
import { Message } from "semantic-ui-react";

interface Props {
  erros: string[];
}

export default function ValidationError({ erros }: Props) {
  return (
    <Message error>
      {erros && (
        <Message.List>
          {erros.map((err: string, i) => (
            <Message.Item key={i}>{err}</Message.Item>
          ))}
        </Message.List>
      )}
    </Message>
  );
}
