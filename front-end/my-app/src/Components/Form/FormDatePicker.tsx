import { TextField } from "@mui/material";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";

interface DatePickerProps {
  label: string;
  value: Date | null;
  onChange(newDate: any): void;
}

const FormDatePicker: React.FC<DatePickerProps> = ({
  label,
  value,
  onChange,
}) => {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <DatePicker
        label={label}
        value={value}
        maxDate={new Date()}
        onChange={onChange}
        renderInput={(params) => (
          <TextField
            {...params}
            fullWidth
            margin="normal"
            required
            name="birthDate"
            id="birthDate"
          />
        )}
      />
    </LocalizationProvider>
  );
};

export default FormDatePicker;
