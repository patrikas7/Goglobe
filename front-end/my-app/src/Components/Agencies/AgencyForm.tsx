import FormContainer from "../Containers/FormContainer";
import { Box, Button, TextField, Typography } from "@mui/material";

const AgencyForm: React.FC = () => {
  const handleOnSubmit = () => {};

  return (
    <FormContainer>
      <Typography component="h1" variant="h5">
        Nauja kelionių agentūra
      </Typography>
      <Box component="form" onSubmit={handleOnSubmit} sx={{ mt: 1 }}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="name"
          label="Pavadinimas"
          name="name"
          autoFocus
        />
        <TextField
          margin="normal"
          required
          fullWidth
          id="address"
          label="Adresas"
          name="address"
        />
        <TextField
          margin="normal"
          fullWidth
          id="logo"
          label="Logotipo nuoroda"
          name="logo"
        />
      </Box>
      <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
        Išsaugoti
      </Button>
    </FormContainer>
  );
};

export default AgencyForm;
