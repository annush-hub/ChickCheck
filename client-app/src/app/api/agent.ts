import axios, { AxiosResponse } from "axios";
import { Barn } from "../models/barn";
import { EggGrade } from "../models/eggGrade";

const sleep = (delay: number) => {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
};

axios.defaults.baseURL = "https://localhost:7080/api";

axios.interceptors.response.use(async (response) => {
  try {
    await sleep(1000);
    return response;
  } catch (error) {
    console.log(error);
    return await Promise.reject(error);
  }
});

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
};

const agent = {
  Barns,
  EggGrades,
};

export default agent;
