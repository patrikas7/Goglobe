import {
  Alert,
  Avatar,
  Box,
  Button,
  Grid,
  Link,
  TextField,
  Typography,
} from "@mui/material";
import AppRegistrationIcon from "@mui/icons-material/AppRegistration";
import FormDatePicker from "../Form/FormDatePicker";
import { useState } from "react";
import {
  containsNumber,
  hasEmailValidFormat,
  hasUpperCase,
  isValidLength,
} from "../../Utils/utils";
import FormContainer from "../Containers/FormContainer";
import axios from "axios";

const ErrorMessages = {
  EMPTY_FIELDS: "Visi laukai yra privalomi!",
  MISSMATCHING_PASSWORDS: "Slaptažodžiai turi sutapti",
  INCORRECT_PASSWORD_FORMAT:
    "Slaptažodį turi sudaryt bent 8 simboliai, įskaitant skaitmenį ir didžiąją raidę",
  INCORRECT_EMAIL_FORMAT: "Netinkamas El. Paštas",
  UNEXPECTED_ERROR: "Įvyko netikėta klaida, bandykite vėliau",
};

const SUCCESS_MESSAGE = "Registracija patvirtinta";

const Registration: React.FC = () => {
  const [birthDate, setBirthDate] = useState<Date | null>(null);
  const [errorMessage, setErrorMessage] = useState("");
  const [isRegistrationSuccessful, setIsRegistrationSuccessful] =
    useState(false);

  const handleOnSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setErrorMessage("");
    const data = new FormData(e.currentTarget);
    const registrationData = {
      name: data.get("name"),
      surname: data.get("surname"),
      email: data.get("email"),
      birthDate: data.get("birthDate"),
      password: data.get("password"),
      passwordRepeat: data.get("passwordRepeat"),
    };

    if (!hasEmailValidFormat(registrationData.email)) {
      setErrorMessage(ErrorMessages.INCORRECT_EMAIL_FORMAT);
      return;
    }

    if (
      !hasUpperCase(registrationData.password) ||
      !containsNumber(registrationData.password) ||
      !isValidLength(registrationData.password)
    ) {
      setErrorMessage(ErrorMessages.INCORRECT_PASSWORD_FORMAT);
      return;
    }

    if (registrationData.password !== registrationData.passwordRepeat) {
      setErrorMessage(ErrorMessages.MISSMATCHING_PASSWORDS);
      return;
    }
  };

  return (
    <FormContainer>
      <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
        <AppRegistrationIcon />
      </Avatar>
      <Typography component="h1" variant="h5">
        Registracija
      </Typography>
      <Box component="form" onSubmit={handleOnSubmit} sx={{ mt: 1 }}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="name"
          label="Vardas"
          name="name"
          autoFocus
        />
        <TextField
          margin="normal"
          required
          fullWidth
          id="surname"
          label="Pavardė"
          name="surname"
        />
        <TextField
          margin="normal"
          required
          fullWidth
          id="email"
          label="El. Paštas"
          name="email"
        />
        <FormDatePicker
          label="Gimimo data"
          value={birthDate}
          onChange={(newDate) => setBirthDate(newDate)}
          required={true}
        />
        <TextField
          margin="normal"
          required
          fullWidth
          name="password"
          label="Slaptažodis"
          type="password"
          id="password"
        />
        <TextField
          margin="normal"
          required
          fullWidth
          name="passwordRepeat"
          label="Pakartokite slaptažodį"
          type="password"
          id="passwordRepeat"
        />

        {errorMessage && <Alert severity="error">{errorMessage}</Alert>}
        {isRegistrationSuccessful && (
          <Alert severity="success">{SUCCESS_MESSAGE}</Alert>
        )}
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Registruotis
        </Button>
        <Grid container justifyContent="center">
          <Grid item>
            <Link href="/login" variant="body2">
              Turite paskyrą? Prisijunkite
            </Link>
          </Grid>
        </Grid>
      </Box>
    </FormContainer>
  );
};

export default Registration;
