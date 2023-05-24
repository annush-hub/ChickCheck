export interface Barn {
  id: string;
  name: string;
  description: string;
  temperatureInCelsius: number;
  temperatureInFahrenheit: number;
  isDeactivated: boolean;
  eggGradeId: string;
}
