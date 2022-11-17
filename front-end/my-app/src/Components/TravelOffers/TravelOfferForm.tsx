import { Box, TextField, Typography } from "@mui/material";
import { useState } from "react";
import FormContainer from "../Containers/FormContainer";
import FormDatePicker from "../Form/FormDatePicker";

const TravelOfferForm: React.FC = () => {
  const [isFormSubmitSuccessful, setIsFormSubmitSuccessful] = useState(false);
  const [departureDate, setDepartureDate] = useState<Date | null>(null);
  const [arivalDate, setArivalDate] = useState<Date | null>(null);

  const handleOnSubmit = (e: React.FormEvent<HTMLFormElement>) => {};

  return (
    <FormContainer>
      <Typography component="h1" variant="h5">
        Naujas kelionės pasiūlymas
      </Typography>
      <Box component="form" onSubmit={handleOnSubmit} sx={{ mt: 1 }}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="country"
          label="Šalis"
          name="country"
        />
        <TextField
          margin="normal"
          required
          fullWidth
          id="city"
          label="Miestas"
          name="city"
        />
        <TextField
          margin="normal"
          required
          fullWidth
          id="price"
          label="Kaina"
          name="price"
          type="number"
        />
        <FormDatePicker
          label="Išvykimo data"
          value={departureDate}
          onChange={(newDate) => setDepartureDate(newDate)}
          required={true}
        />
        <FormDatePicker
          label="Atvykimo data"
          value={arivalDate}
          onChange={(newDate) => setArivalDate(newDate)}
          required={true}
        />
        <TextField
          margin="normal"
          required
          fullWidth
          id="personCount"
          label="Žmonių skaičius"
          name="persconCount"
          type="number"
        />
        <TextField
          margin="normal"
          fullWidth
          id="description"
          label="Aprašymas"
          name="description"
          type="description"
          multiline
          minRows={3}
        />
      </Box>
    </FormContainer>
  );
};

export default TravelOfferForm;
