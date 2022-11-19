import { useState } from "react";
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
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import api from "../Api/api";
import FormContainer from "../Containers/FormContainer";
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import axios from "axios";

const ErrorMessages = {
  EMPTY_FIELDS: "Visi laukai yra privalomi!",
  WRONG_LOGIN: "Neteisingi prisijungimo duomenys",
  UNEXPECTED_ERROR: "Įvyko nenumatyta klaida, bandykite vėliau",
};

const Login: React.FC = () => {
  const [errorMessage, setErrorMessage] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const handleOnSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setIsLoading(true);
    setErrorMessage("");
    const formData = new FormData(e.currentTarget);
    const loginData = {
      email: formData.get("email"),
      password: formData.get("password"),
    };

    try {
      const { data } = await api.post("/login", loginData);
      sessionStorage.setItem("token", data.accessToken);
      sessionStorage.setItem("user", "client");
      sessionStorage.setItem("name", data.name);
      window.location.href = "/";
    } catch (error: any) {
      if (axios.isAxiosError(error)) {
        error?.response?.status === 400
          ? setErrorMessage(ErrorMessages.WRONG_LOGIN)
          : setErrorMessage(ErrorMessages.UNEXPECTED_ERROR);
      }
    }

    setIsLoading(false);
  };

  return (
    <FormContainer>
      <LoadingSpinner isOpen={isLoading} />
      <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
        <LockOutlinedIcon />
      </Avatar>
      <Typography component="h1" variant="h5">
        Prisijungimas
      </Typography>
      <Box component="form" onSubmit={handleOnSubmit} sx={{ mt: 1 }}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="email"
          label="El. Paštas"
          name="email"
          autoComplete="email"
          autoFocus
        />
        <TextField
          margin="normal"
          required
          fullWidth
          name="password"
          label="Slaptažodis"
          type="password"
          id="password"
          autoComplete="current-password"
        />

        {errorMessage && <Alert severity="error">{errorMessage}</Alert>}
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Prisijungti
        </Button>
        <Grid container>
          <Grid item xs>
            <Link href="#" variant="body2">
              Pamiršote Slaptažodį?
            </Link>
          </Grid>
          <Grid item>
            <Link href="/register" variant="body2">
              Neturite paskyros? Užsiregistruokite
            </Link>
          </Grid>
        </Grid>
      </Box>
    </FormContainer>
  );
};

export default Login;
