import React from "react";
import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import BarnDashboard from "../../features/barns/dashboard/BarnDashboard";
import BarnForm from "../../features/barns/form/BarnForm";
import BarnDetails from "../../features/barns/details/BarnDetails";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
      { path: "barns", element: <BarnDashboard /> },
      { path: "barns/:id", element: <BarnDetails /> },
      { path: "createBarn", element: <BarnForm key="create" /> },
      { path: "edit/:id", element: <BarnForm key="edit" /> },
    ],
  },
];

export const router = createBrowserRouter(routes);
