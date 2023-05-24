import React from "react";
import { Header, Menu } from "semantic-ui-react";

export default function BarnFilters() {
  return (
    <>
      <Menu vertical size="large" style={{ width: "100%", marginTop: 25 }}>
        <Header icon="filter" attached color="teal" content="Filters" />
        <Menu.Item content="All Barns" />
        <Menu.Item content="Active" />
        <Menu.Item content="Not active" />
      </Menu>
      <Header />
    </>
  );
}
