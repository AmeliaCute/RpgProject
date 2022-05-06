// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "PCharacter.generated.h"

UCLASS()
class RPGPROJECT_API APCharacter : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	APCharacter();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

protected:
	// Boolean to know if player is sprinting
	bool isSprinting = false;
	
	// Boolean to know if player do something where normally he can't move
	bool isBusy = false;

	// Start sprint mode
	void SprintStart();

	// Stop sprint
	void SprintStop();

	// Move forward or backward
	void MoveZ(float axis);

	// Move to the left or the right
	void MoveX(float axis);

	void OpenInventory();

	void CloseInventory();
};
