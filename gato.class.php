<?php

class Gato{
	private $board = array();
	private $circulo = 0;
	private $equis = 1;
	private $hayGanador = false;
	private $ganador = -1;

	public function __construct(){

	}

	public function newGame(){
		$this->board = array_fill(0, 9, -1);
		$this->hayGanador = false;
		$this->ganador = "";
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
					return $this->getBoard();
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
		$tmpBoard = array();
		foreach ($this->board as $boardValue) { 
			$tmpBoard[] = $boardValue;
		}
		$result = "" . $tmpBoard[0];
		for($i = 1; $i < 9; $i++) { 
			$result = $result . "," . $tmpBoard[$i];
		}
		return $result;
	}


}

?>