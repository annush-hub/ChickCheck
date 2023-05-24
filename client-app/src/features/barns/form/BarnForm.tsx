import React, { ChangeEvent, FormEvent, useEffect, useState } from "react";
import {
  Button,
  CheckboxProps,
  DropdownProps,
  Form,
  Segment,
} from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Barn } from "../../../app/models/barn";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { v4 as uuid } from "uuid";

export default observer(function BarnForm() {
  const { barnStore, eggGradeStore } = useStore();
  const { createBarn, updateBarn, loading, loadBarn, loadingiInitial } =
    barnStore;

  const { id } = useParams();
  const navigate = useNavigate();

  const [barn, setBarn] = useState<Barn>({
    id: "",
    name: "",
    description: "",
    temperatureInCelsius: 0,
    temperatureInFahrenheit: 0,
    isDeactivated: false,
    eggGradeId: "",
  });

  useEffect(() => {
    if (id) {
      loadBarn(id).then((barn) => {
        if (barn) {
          setBarn(barn);
          setSelectedEggGrade(barn.eggGradeId); // Set the initial selected egg grade
        }
      });
    }
  }, [id, loadBarn]);

  const { eggGradeList: eggGrades } = eggGradeStore;

  //const [selectedEggGrade, setSelectedEggGrade] = useState(barn.eggGradeId);
  const [selectedEggGrade, setSelectedEggGrade] = useState<string>(
    barn.eggGradeId
  );
  if (loadingiInitial) return <LoadingComponent content="Loading barn..." />;

  function handleSubmit() {
    if (!barn.id) {
      barn.id = uuid();
      createBarn(barn).then(() => navigate(`/barns/${barn.id}`));
    } else {
      updateBarn(barn).then(() => navigate(`/barns/${barn.id}`));
    }
  }

  function handleInputChange(
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) {
    const { name, value, type } = event.target;

    let inputValue: string | number | boolean = value;

    if (type === "number") {
      const numericValue = parseFloat(value);
      if (!isNaN(numericValue) && numericValue >= 17 && numericValue <= 25) {
        inputValue = numericValue;
      } else {
        inputValue = "";
      }
    }
    setBarn((barn) => ({ ...barn, [name]: value }));
  }

  function handleCheckboxChange(
    event: FormEvent<HTMLInputElement>,
    data: CheckboxProps
  ) {
    const { name, checked } = data;

    setBarn((barn) => ({ ...barn, [name as string]: checked }));
  }

  function handleEggGradeChange(
    event: React.SyntheticEvent<HTMLElement, Event>,
    data: DropdownProps
  ) {
    const { value } = data;
    setSelectedEggGrade(value as string);

    const selectedEggGrade = eggGrades.find(
      (eggGrade) => eggGrade.id === value
    );

    setBarn((prevBarn) => ({
      ...prevBarn,
      eggGradeId: value as string,
      eggGrade: selectedEggGrade?.gradeUA || "",
    }));
  }

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit} autoComplete="off">
        <Form.Input
          placeholder="Name"
          value={barn.name}
          name="name"
          onChange={handleInputChange}
        />
        <Form.TextArea
          placeholder="Description"
          name="description"
          value={barn.description}
          onChange={handleInputChange}
        />
        <Form.Input
          type="number"
          placeholder="Temperature in Celcius"
          name="temperatureInCelsius"
          value={barn.temperatureInCelsius}
          onChange={handleInputChange}
        />
        <Form.Select
          label="Egg Grade"
          name="eggGradeId"
          placeholder="Select egg grade"
          options={eggGrades.map((eggGrade) => ({
            key: eggGrade.id,
            value: eggGrade.id,
            text: eggGrade.gradeUA,
          }))}
          value={selectedEggGrade}
          onChange={handleEggGradeChange}
        />

        <Form.Checkbox
          label="Is Deactivated"
          name="isDeactivated"
          checked={barn.isDeactivated}
          onChange={handleCheckboxChange}
        />

        <Button
          floated="right"
          positive
          type="submit"
          content="Submit"
          loading={loading}
        />
        <Button
          as={Link}
          to="/barns"
          floated="right"
          type="button"
          content="Cancel"
        />
      </Form>
    </Segment>
  );
});
