<?php

class Gato{
	public $board;
	public $circulo;
	public $equis;
	public $hayGanador;
	public $ganador;

	public function __construct(){
		$this->board = array();
		for($i=0; $i<9; $i++) {
			$this->board[$i] = -1;
		}
		$this->circulo = 0;
		$this->equis = 1;
		$this->hayGanador = false;
		$this->ganador = -1;
	}

	public function newGame(){
		for ($i=0; $i<9; $i++){
			$this->board[$i] = -1;
		}
		$this->hayGanador = false;
		$this->ganador = -1;
	}

	public function saveScores($ranking){
		 $file = fopen('Highscores.txt', 'w');
		 if(fputs($file, $ranking)){
			fclose($file);
			return true;
		}
		 else{
			fclose($file);
			return false;
		}
	}

	public function loadScores(){
		$file = fopen('Highscores.txt', 'r');
		$scores = "";
		while(($line = fgets($file)) && !feof($file))
		{
			$scores = $scores.$line."\n";
		}
		fclose($file);
		return $scores;
	}

	public function play($simbolo, $indice){
		if($this->hayGanador){
			return "GAME OVER";
		}
		if($indice >= 0 && $indice <= 8 && ($simbolo == 0 || $simbolo == 1)){
			if($this->board[$indice] == -1){
				$this->board[$indice] = $simbolo;
				if($this->checkWinner($simbolo, $indice)){
					return "GAME OVER";
				}
				else{
					$c = 0;
					foreach($this->board as $b){
						if($b != -1){
							$c++;
						}
					}
					if($c == 9){
						return "EMPATE";
					}
					else{
						return $this->getBoard();
					}
				}
			}
			else
				return "INVALID PLAY";
		}
		else
			return "ERROR";
	}

	public function checkWinner($simbolo, $indice){
		if(!$this->hayGanador){
			//check vertical
			$a = $indice;
			$b = ($a + 3) % 9;
			$c = ($b + 3) % 9;
			if($this->board[$a] == $this->board[$b] && $this->board[$b] == $this->board[$c]){
				$this->hayGanador = true;
				$this->ganador = $simbolo;
				return true;
			}
			else{
				//check horizontal
				if($a < 3)
					$row = 0;
				else if($a < 6)
					$row = 1;
				else
					$row = 2;

				$a = $row * 3;
				$b = $a + 1;
				$c = $b + 1;

				if($this->board[$a] == $this->board[$b] && $this->board[$b] == $this->board[$c]){
					$this->hayGanador = true;
					$this->ganador = $simbolo;
					return true;
				}
				else{
					//check diagonal
					//solo indices pares!
					if($indice % 2 == 0){
						//revisar diagonal
						if($indice % 4 == 0){
							if($this->board[0] == $this->board[4] && $this->board[4] == $this->board[8]){
								$this->hayGanador = true;
								$this->ganador = $simbolo;
								return true;
							}
						}
						//revisar anti-diagonal
						if($indice != 0 && $indice != 8){
							if($this->board[2] == $this->board[4] && $this->board[4] == $this->board[6]){
								$this->hayGanador = true;
								$this->ganador = $simbolo;
								return true;
							}
						}
						else
							return false;
					}
				}
			}
		}
		else
			return false;
	}

	public function getWinner(){
		if($this->hayGanador){
			return $this->ganador;
		}
		else
			return "No winner";
	}

	public function getBoard(){
		$result = $this->board[0];
		for($i = 1; $i < 9; $i++) {
			$result = $result . "," . $this->board[$i];
		}
		return $result;
	}


}

?>