import React from "react";
import { useStore } from "../../../app/stores/store";
import StorageListItem from "./StorageListItem";

export default function StorageList() {
  const { storageStore } = useStore();
  const { storageList } = storageStore;
  return (
    <>
      {storageList.map((storage) => (
        <StorageListItem key={storage.id} storage={storage} />
      ))}
    </>
  );
}
