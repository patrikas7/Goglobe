import { FormControl, Input, InputAdornment } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import { useState } from "react";

const SearchBar: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const handleOnSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log("subgmi");
  };

  return (
    <form onSubmit={handleOnSubmit}>
      <FormControl
        sx={{ width: "250px", marginRight: "50px" }}
        variant="standard"
      >
        <Input
          id="destination-search"
          placeholder="Kelionės paieška..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          endAdornment={
            <InputAdornment position="end">
              <SearchIcon></SearchIcon>
            </InputAdornment>
          }
        />
      </FormControl>
    </form>
  );
};

export default SearchBar;
