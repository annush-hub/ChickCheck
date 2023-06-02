import axios, { AxiosError, AxiosResponse } from "axios";
import { Barn } from "../models/barn";
import { EggGrade } from "../models/eggGrade";
import { toast } from "react-toastify";
import { router } from "../router/Routes";
import { store } from "../stores/store";
import { EggStorage } from "../models/storage";
import { User, UserFormValues } from "../models/user";
import { Feeder } from "../models/feeder";

const sleep = (delay: number) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
};

axios.defaults.baseURL = "https://localhost:7080/api";

axios.interceptors.request.use((config) => {
  const token = store.commonStore.token;
  if (config.headers && token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

axios.interceptors.response.use(
  async (response) => {
    await sleep(1000);
    return response;
  },
  (error: AxiosError) => {
    const { data, status, config } = error.response as AxiosResponse;
    switch (status) {
      case 400:
        if (config.method === "get" && data.errors.hasOwnProperty("id")) {
          router.navigate("/not-found");
        }
        if (data.errors) {
          const modalStateErrors = [];
          for (const key in data.errors) {
            if (data.errors[key]) {
              modalStateErrors.push(data.errors[key]);
            }
          }
          throw modalStateErrors.flat();
        } else {
          toast.error(data);
        }
        break;
      case 401:
        toast.error("unauthorised");
        break;
      case 403:
        toast.error("forbidden");
        break;
      case 404:
        router.navigate("/not-found");
        break;
      case 500:
        store.commonStore.setServerError(data);
        router.navigate("/server-error");
        break;
    }
    return Promise.reject(error);
  }
);

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
};

const Barns = {
  list: () => requests.get<Barn[]>("/barns/short"),
  details: (id: string) => requests.get<Barn>(`/barns/${id}`),
  create: (barn: Barn) => requests.post<void>("/barns", barn),
  update: (barn: Barn) => requests.put<void>(`/barns/${barn.id}`, barn),
};

const EggGrades = {
  list: () => requests.get<EggGrade[]>("/eggGrades"),
  details: (id: string) => requests.get<EggGrade>(`/eggGrades/${id}`),
};

const Storages = {
  list: () => requests.get<EggStorage[]>("/storages"),
};

const Account = {
  current: () => requests.get<User>("/account"),
  register: (user: UserFormValues) =>
    requests.post<User>("/account/registerUser", user),
  login: (user: UserFormValues) => requests.post<User>("/account/login", user),
};

const Feeders = {
  create: (feeder: Feeder) => requests.post<void>("/feeders", feeder),
};

const agent = {
  Barns,
  EggGrades,
  Storages,
  Account,
  Feeders,
};

export default agent;
