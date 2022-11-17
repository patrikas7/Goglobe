import { TextField } from "@mui/material";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";

interface DatePickerProps {
  label: string;
  value: Date | null;
  onChange(newDate: any): void;
  required?: boolean;
}

const FormDatePicker: React.FC<DatePickerProps> = ({
  label,
  value,
  onChange,
  required,
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
            required={required}
            name={label}
            id={label}
          />
        )}
      />
    </LocalizationProvider>
  );
};

export default FormDatePicker;
