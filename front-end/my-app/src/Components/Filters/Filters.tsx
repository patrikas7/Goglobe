import { Button, TextField } from "@mui/material";
import { useState } from "react";
import FormDatePicker from "../Form/FormDatePicker";
import NumberSlider from "../Slider/NumberSlider";

const Filters: React.FC = () => {
  const [departureDate, setDepartureDate] = useState<Date | null>(null);
  const [arrivalDate, setArrivalDate] = useState<Date | null>(null);
  const [priceRange, setPriceRange] = useState<number | number[]>([50, 10000]);

  const handleOnSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log("opa");
  };

  return (
    <div className="filters-container">
      <h3>Filtrai</h3>
      <form onSubmit={handleOnSubmit}>
        <TextField
          margin="normal"
          fullWidth
          id="destination"
          label="Kelionės tikslas"
          name="destination"
        />
        <FormDatePicker
          label="Išvykimo data"
          value={departureDate}
          onChange={(newDate) => setDepartureDate(newDate)}
        />
        <FormDatePicker
          label="Atvykimo data"
          value={arrivalDate}
          onChange={(newDate) => setArrivalDate(newDate)}
        />
        <NumberSlider
          leftLabel="Min. Kaina"
          rightLabel="Max. Kaina"
          value={priceRange}
          onChange={setPriceRange}
        />

        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Filtruoti
        </Button>
      </form>
    </div>
  );
};

export default Filters;
