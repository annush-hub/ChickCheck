import React from "react";
import { Navigate, RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import BarnDashboard from "../../features/barns/dashboard/BarnDashboard";
import BarnForm from "../../features/barns/form/BarnForm";
import BarnDetails from "../../features/barns/details/BarnDetails";
import TestErrors from "../../features/errors/TestError";
import NotFound from "../../features/errors/NotFound";
import ServerError from "../../features/errors/ServerError";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
      { path: "barns", element: <BarnDashboard /> },
      { path: "barns/:id", element: <BarnDetails /> },
      { path: "createBarn", element: <BarnForm key="create" /> },
      { path: "edit/:id", element: <BarnForm key="edit" /> },
      { path: "errors", element: <TestErrors /> },
      { path: "not-found", element: <NotFound /> },
      { path: "server-error", element: <ServerError /> },
      { path: "*", element: <Navigate replace to="/not-found" /> },
    ],
  },
];

export const router = createBrowserRouter(routes);
