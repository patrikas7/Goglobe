import { Stack } from "@mui/material";
import Slider from "@mui/material/Slider";

interface SliderProps {
  leftLabel: string;
  rightLabel: string;
  value: number | number[];
  onChange(value: number | Array<number>): void;
}

const NumberSlider: React.FC<SliderProps> = ({
  leftLabel,
  rightLabel,
  value,
  onChange,
}) => {
  return (
    <Stack spacing={2} direction="row" alignItems="center" sx={{ m: 2 }}>
      <span className="slider-label">{leftLabel}</span>
      <Slider
        value={value}
        valueLabelDisplay={"auto"}
        onChange={(event: Event, value: number | Array<number>) =>
          onChange(value)
        }
        min={50}
        max={10000}
        step={50}
      />
      <span className="slider-label">{rightLabel}</span>
    </Stack>
  );
};

export default NumberSlider;
