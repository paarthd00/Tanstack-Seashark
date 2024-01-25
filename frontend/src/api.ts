import axios from "axios"

export type Gun= {
  id: number;
  Name: string;
  Power: number;
  Weight: number;
};

export async function getGuns(): Promise<Gun[]>{
  return await axios.get("/api/guns");
}
