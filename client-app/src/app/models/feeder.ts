export interface Feeder {
  id: string;
  capacity: number;
  fullness: number;
  isInUse: boolean;
  barnId: string;
}
