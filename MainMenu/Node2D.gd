extends Node2D


# Called when the node enters the scene tree for the first time.
func _ready():
	Wwise.register_game_obj(self, "test")
	Wwise.post_event("Player_Fireball_Shoot", self)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
