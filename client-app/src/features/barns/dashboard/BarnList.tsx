import { Fragment } from "react";
import { Header } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import BarnListItem from "./BarnListItem";

export default function BarnList() {
  const { barnStore, eggGradeStore } = useStore();
  const { groupedBarns } = barnStore;
  const { eggGradeList: eggGrades } = eggGradeStore;
  return (
    <>
      {groupedBarns.map(([group, barns]) => (
        <Fragment key={group}>
          <Header sub color="teal">
            {eggGrades.find((x) => x.id === group)?.gradeUA}
          </Header>
          {barns.map((barn) => (
            <BarnListItem key={barn.id} barn={barn} />
          ))}
        </Fragment>
      ))}
    </>
  );
}
