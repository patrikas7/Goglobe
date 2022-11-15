import { useState } from "react";
import {
  Avatar,
  Box,
  Button,
  Container,
  createTheme,
  CssBaseline,
  Grid,
  Link,
  TextField,
  ThemeProvider,
  Typography,
} from "@mui/material";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import ErrorMessage from "../Error/ErrorMessage";
import api from "../Api/api";
import { hasObjectEmptyValues } from "../../Utils/utils";

const ErrorMessages = {
  EMPTY_FIELDS: "Visi laukai yra privalomi!",
  WRONG_LOGIN: "Neteisingi prisijungimo duomenys",
  UNEXPECTED_ERROR: "Įvyko netikėta klaida, bandykite vėliau",
};

const Login: React.FC = () => {
  const [errorMessage, setErrorMessage] = useState("");

  const handleOnSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setErrorMessage("");
    const data = new FormData(e.currentTarget);
    const loginData = {
      email: data.get("email"),
      password: data.get("password"),
    };

    if (hasObjectEmptyValues(loginData)) {
      setErrorMessage(ErrorMessages.EMPTY_FIELDS);
      return;
    }

    const login = await api.post("/login", loginData);
    console.log(login);
  };

  const theme = createTheme();

  return (
    <ThemeProvider theme={theme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Prisijungimas
          </Typography>
          <Box
            component="form"
            onSubmit={handleOnSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
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
            {errorMessage && <ErrorMessage message={errorMessage} />}
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
        </Box>
      </Container>
    </ThemeProvider>
  );
};

export default Login;
